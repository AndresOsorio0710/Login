import React from "react";
import { Route, Routes } from "react-router-dom";
import { Box } from "@mui/material";
import Navbar from "./navbar";
import Login from "./acces/login";
import Register from "./acces/register";
import Acces from "./../models/acces";

const Master = () => {
  const handleLogin = async (data: Acces) => {
    console.log("Login: ",data);
  };
  return (
    <Box sx={{ flexGrow: 1 }}>
      <Box sx={{}} className="navbar">
        <Navbar />
      </Box>
      <Routes>
        <Route path={"/login"} element={<Login handleLogin={handleLogin}/>} />
        <Route path={"/register"} element={<Register />} />
      </Routes>
    </Box>
  );
};

export default Master;
