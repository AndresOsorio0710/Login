import { AppBar, Button, Toolbar, Typography } from "@mui/material";
import { makeStyles } from "@mui/styles";
import { Link } from "react-router-dom";
import Theme from "../themeConfig";
import React from "react";

const useStyles = makeStyles(() => ({
  offset: Theme.mixins.toolbar,
  link: {
    textDecoration: "none",
    color: "white",
  },
}));

const Navbar = () => {
  const classes = useStyles();
  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h6" sx={{ flexGrow: 1 }}>
          App Login
        </Typography>
        <Button variant="text" color="inherit">
          <Link to="/login" className={classes.link}>
            logIn
          </Link>
        </Button>
        <Button variant="text" color="inherit">
          <Link to="/register" className={classes.link}>
            Register
          </Link>
        </Button>
      </Toolbar>
    </AppBar>
  );
};

export default Navbar;
