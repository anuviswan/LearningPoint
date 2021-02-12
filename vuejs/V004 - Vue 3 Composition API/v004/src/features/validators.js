const minLength = min =>{
    return input => input.length < min ? `invalid length : ${min}`:null;
}

const isEmail = () => {
    const re = /\S+@\S+\.\S+/;
    return input => re.test(input)
    ? null
    : "Must be a valid email address";
  }
  
  export { minLength, isEmail };