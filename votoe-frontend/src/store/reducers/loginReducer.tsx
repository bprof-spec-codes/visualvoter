export const initialState:IInitState={
    user: null,
}

interface IInitState{
    user: object | null;
}

const loginReducer = (state = initialState, action: any) => {
    switch (action.type) {
      case "SIGN_IN":
        return {
            ...state,
            user: action.payload,
        };
      default:
        return state;
    }
  };
  
  export default loginReducer;