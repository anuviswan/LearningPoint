import {ref,watch} from "vue"

export default function(startValue,validators,onValidate){
    const input = ref(startValue);
    console.log("inpout",input)
    const errors = ref([]);

    watch(input,value=>{
        errors.value = validators.map(validator=> validator(value));
        onValidate(value);
    })

    return{
        input,
        errors
    };
}