import React from 'react'
import { useState } from 'react'
import axios from "axios";
import { Stack, PrimaryButton, TextField, DatePickerBase } from "@fluentui/react"
import { useLocation, useNavigate } from 'react-router-dom';
export default function AddMember() {
    const location = useLocation();
    const navigate = useNavigate();
    const bookId = location.state?.id;
    const baseUrl = "https://localhost:7009";
    const headers = {
        Accept: "application/json",
        "Content-Type": "application/json",
        "Access-Control-Allow-Origin": "*",
    };
    const [pageData, setPageData] = useState({
        bookId: bookId,
        name: "",
        surName: "",
        deliveryTime: ""
    });
    const onChangeText = (e) => {
        const { name, value } = e.target;
        setPageData({ ...pageData, [name]: value })
    };
    const BorrowBook = () => {
        axios
            .post(`${baseUrl}/api/Member/AddMember`, pageData, { headers: headers })
            .then((res) => {
                if (res.status === 200) {
                    navigate("/")
                    alert("Book borrowed successfully");
                }
            })
    }

    return (
        <div className="content">
            <div className="content-header">Borrow Book</div>
            <Stack
                tokens={{ childrenGap: 10 }}
                styles={
                    {
                        root: {
                            width: 700,
                            marginLeft: 10,
                            marginTop: 10
                        }
                    }
                }>
                <TextField
                    label="Name"
                    name="name"
                    value={pageData.name}
                    placeholder={"Please enter the name"}
                    onChange={onChangeText}
                    required
                />
                <TextField
                    label="SurName"
                    name="surName"
                    value={pageData.surName}
                    placeholder={"Please enter surname"}
                    onChange={onChangeText}
                    required
                />
                <DatePickerBase
                    label="Delivery Time"
                    name="deliveryTime"
                    value={pageData.deliveryTime}
                    placeholder={"Please select Delivery Time"}
                    onSelectDate={(date) => setPageData({ ...pageData, "deliveryTime": date })}
                    required
                />
                <PrimaryButton
                    text="Borrow Book"
                    onClick={() => BorrowBook()}
                    style={{ width: "10%", height: "50px" }}
                />
            </Stack>
        </div>
    )
}
