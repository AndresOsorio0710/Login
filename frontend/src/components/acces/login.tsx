import {
  Button,
  FormControl,
  IconButton,
  InputAdornment,
  InputLabel,
  OutlinedInput,
  TextField,
  Typography,
} from "@mui/material";
import React, { useState } from "react";
import { Box } from "@mui/system";
import { Visibility, VisibilityOff } from "@mui/icons-material";
import * as Yup from "yup";
import { useFormik } from "formik";
import Acces from "../../models/acces";

const validationSchema = Yup.object().shape({
  user: Yup.string().required("The User is required."),
  password: Yup.string().required("The Password is required."),
});

interface Props {
  handleLogin: (data: Acces) => void;
}

const Login: React.FC<Props> = ({ handleLogin }) => {
  const [showPassword, setShowPassword] = useState<boolean>(false);

  const handleShowPassword = () => {
    setShowPassword(!showPassword);
  };

  const login = (data: any, { resetForm }: any) => {
    handleLogin(data);
    resetForm({});
  };

  const initValue = () => {
    return {
      user: "",
      password: "",
    };
  };

  const formik = useFormik({
    initialValues: initValue(),
    validationSchema,
    onSubmit: login,
  });

  return (
    <Box sx={{ flexGrow: 1 }}>
      <Box className="header">
        <Typography variant="h6">Login</Typography>
      </Box>
      <Box className="inside">
        <form onSubmit={formik.handleSubmit}>
          <TextField
            fullWidth
            id="user"
            name="user"
            label="User"
            type="text"
            size="small"
            onChange={formik.handleChange}
            value={formik.values.user}
          />
          {formik.errors.user && formik.touched.user ? (
            <Box>{formik.errors.user}</Box>
          ) : null}
          <FormControl fullWidth variant="outlined">
            <InputLabel htmlFor="password">Password</InputLabel>
            <OutlinedInput
              id="password"
              name="password"
              type={showPassword ? "text" : "password"}
              label="Password"
              size="small"
              onChange={formik.handleChange}
              value={formik.values.password}
              endAdornment={
                <InputAdornment position="end">
                  <IconButton
                    aria-label="toggle password visibility"
                    onClick={handleShowPassword}
                    edge="end"
                  >
                    {showPassword ? <VisibilityOff /> : <Visibility />}
                  </IconButton>
                </InputAdornment>
              }
            />
            {formik.errors.password && formik.touched.password ? (
              <Box>{formik.errors.password}</Box>
            ) : null}
            <Button fullWidth variant="contained" type="submit">
              Ingresar
            </Button>
          </FormControl>
        </form>
      </Box>
      <Box className="footer"></Box>
    </Box>
  );
};

export default Login;
