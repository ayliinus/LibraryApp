using Context;
using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Business
{
    public class MemberBusinessSerive : IMemberBusinessSerive
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemberRepositoryService _memberRepository;
        private readonly IBookRepositoryService _bookRepository;

        public MemberBusinessSerive(ApplicationDbContext context, IMemberRepositoryService memberRepository = null, IBookRepositoryService bookRepository = null)
        {
            _context = context;
            _memberRepository = memberRepository;
            _bookRepository = bookRepository;
        }

        public void CreateBorrower(AddMemberVM model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var newMember = new Member
                    {
                        Name = model.Name,
                        SurName = model.SurName,
                        BookId = model.BookId,
                        DeliveryDate = model.DeliveryTime
                    };

                    _memberRepository.Add(newMember);
                    var book = _bookRepository.GetFirst(b => b.Id == model.BookId);
                    book.Active = false;
                    _bookRepository.Update(book);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
