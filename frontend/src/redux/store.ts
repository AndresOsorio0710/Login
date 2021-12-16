import { createStore, combineReducers, compose, applyMiddleware } from "redux";
import thunck from "redux-thunk";

const rooReducer = combineReducers({});

declare global {
  interface Window {
    __REDUX_DEVTOOLS_EXTENSION_COMPOSE__?: typeof compose;
  }
}

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

export default function generateStore() {
  const store = createStore(
    rooReducer,
    composeEnhancers(applyMiddleware(thunck))
  );
  return store;
}
