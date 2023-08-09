import React, {useState} from 'react'
import axios from "axios";
import {Stack,PrimaryButton,TextField} from "@fluentui/react"
import { useNavigate} from 'react-router-dom';
export default function CreateBook() {
    const[pageData,setPageData] = useState({
        name:"",
        author:"",
        image:""
    });
    const navigate = useNavigate();
    const baseUrl = "https://localhost:7009";
    const headers = {
        Accept: "application/json",
        "Content-Type": "application/json",
        "Access-Control-Allow-Origin": "*",
    };
    const onChangeText=(e)=>{
        const {name,value}=e.target;
        setPageData({...pageData,[name]: value}) 
    };
    const AddBook=()=>{
        axios
        .post(`${baseUrl}/api/Book/AddBook`, pageData, { headers: headers })
        .then((res) => {
            if (res.status === 200) {
                navigate("/")
                alert("Book created successfully");
            }
        })
    }
  return (
    <div className="content">
            <div className="content-header">Create Book</div>
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
                    label="Author"
                    name="author"
                    value={pageData.author}
                    placeholder={"Please enter author"}
                    onChange={onChangeText}
                    required
                />
                <TextField
                    label="Image"
                    name="image"
                    value={pageData.image}
                    placeholder={"Please enter image URL here"}
                    onChange={onChangeText}
                    required
                />
                <PrimaryButton
                    text="Create Book"
                    onClick={() => AddBook()}
                    style={{ width: "10%", height: "50px" }}
                />
            </Stack>
        </div>
  )
}
