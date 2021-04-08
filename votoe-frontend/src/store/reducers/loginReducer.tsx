
export const initialState:IInitState={
    Email:'',
    Password:'',
}

interface IInitState{
    Email:string;
    Password:string;
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