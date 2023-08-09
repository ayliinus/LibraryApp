import React from "react";
import { Routes, Route } from "react-router-dom";
import CreateBook from "./pages/CreateBook";
import Books from "./pages/Books";
import AddMember from "./pages/AddMember";


export const App = () => {
    return (
        <Routes>
                <Route path="/create-book" element={<CreateBook />} />
                <Route path='/' element={<Books/>}></Route>
                <Route path='/add-member/:id' element={<AddMember/>}></Route>
        </Routes>
    );
};

export default App;
