export const increment=(nr:any)=>{
    return {
        type: 'INCREMENT',
        payload:nr,
    }
}
export const decrement=()=>{
    return {
        type: 'DECREMENT',
    }
}

export const login=(obj:any)=>{
    return {
        type: 'SIGN_IN',
        payload: obj
    }
}