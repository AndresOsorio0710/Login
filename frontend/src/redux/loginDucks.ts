import User from "../models/user";
import axios from "axios";

const dataInitial = {
  array: [],
  dataEdit: {},
};

const GET_USERS_SUCCESS = "GET_USERS_SUCCESS";
const GET_USER_ID_SUCCESS = "GET_USER_ID_SUCCESS";
const POST_USER_SUCCESS = "POST_USER_SUCCESS";
const DELETED_USER_SUCCESS = "DELETED_USER_SUCCESS";

export default function logindReducer(state = dataInitial, action: any) {
  switch (action.type) {
    default:
      return state;
  }
}

export const getUsers = () => async (dispatch: any) => {
  try {
    const answer = await axios.get(process.env.REACT_APP_LOGIN_BASE_URL + "");
    console.log("Answer: " + answer);
    dispatch({ type: GET_USERS_SUCCESS, payload: answer.data });
  } catch (error) {
    alert("Error: " + error);
  }
};
