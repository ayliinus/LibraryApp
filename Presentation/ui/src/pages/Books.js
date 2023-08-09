import React from 'react'
import { useEffect, useState } from "react";
import axios from "axios";
import { DetailsList, SelectionMode, Stack, PrimaryButton } from "@fluentui/react";
import { useNavigate } from 'react-router-dom';

const baseUrl = "https://localhost:7009";
const columnProps = {
    tokens: { childrenGap: 20 },
    style: { root: { width: 100 } }
}
export default function Books() {
    const [books, setBooks] = useState([]);
    const navigate = useNavigate();

    const columns = [
        {
            key: "id",
            name: "Id",
            fieldName: "id",
            minWidth: 10,
            maxWidth: 50,
            isRowHeader: true,
        },
        {
            key: "bookImage",
            name: "Image",
            fieldName: "imgUrl",
            minWidth: 200,
            maxWidth: 250,
            isRowHeader: true,
            onRender: (item) => (
                <img
                    src={item.bookImage}
                    style={{ width: "200px", height: "250px" }}
                    alt={`${item.name}- ${item.author}`}


                ></img>
            )
        },
        {
            key: "bookName",
            name: "Name",
            fieldName: "bookName",
            minWidth: 100,
            maxWidth: 150,
            isRowHeader: true
        },
        {
            key: "author",
            name: "Author",
            fieldName: "author",
            minWidth: 100,
            maxWidth: 200,
            isRowHeader: true
        },
        {
            key: "onLoan",
            name: "Avaible To Give",
            fieldName: "onLoan",
            minWidth: 100,
            maxWidth: 200,
            isRowHeader: true
        },
        {
            key: "customerName",
            name: "Borrower",
            fieldName: "customerName",
            minWidth: 300,
            maxWidth: 500,
            isRowHeader: true
        },
        {
            key: "deliveryDate",
            name: "Delivery Date",
            fieldName: "deliveryDate",
            minWidth: 300,
            maxWidth: 500,
            isRowHeader: true
        },
        {
            key: "process",
            name: "Action",
            fieldName: "Action",
            minWidth: 300,
            maxWidth: 500,
            isRowHeader: true,
            onRender: (item) => (
                <Stack {...columnProps} horizontal>
                    <PrimaryButton
                        text="Borrow"
                        disabled={item.onLoan === "No" ? true : false}
                        onClick={() => navigate("/add-member/" + item.id,
                            { state: { id: item.id } })} />
                </Stack>

            )
        }

    ]
    const headers = {
        Accept: "application/json",
        "Content-Type": "application/json",
        "Access-Control-Allow-Origin": "*",
    };
    function GetBooks() {
        process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";
        axios
            .get(`${baseUrl}/api/Book/GetAllBooks`, { headers: headers })
            .then((response) => {
                console.log(response);
                setBooks(response.data);
            })
            .catch((error) => {
                console.error("Error fetching books:", error);
            });
    }
    useEffect(() => {
        GetBooks();
    }, []);

    return (

        <div className='container-fluid'>
            <div className='content'>
                <div className='content-header fw-bold'><h1>Books</h1>
                    <div className='content-header'><PrimaryButton
                        text="Create Book"
                        onClick={() => navigate("/create-book")}
                        style={{ width: "10%", height: "50px" }}
                    /></div></div>
                <DetailsList
                    items={books}
                    columns={columns}
                    SelectionMode={SelectionMode.none}
                />
            </div>
        </div>

    )
}
