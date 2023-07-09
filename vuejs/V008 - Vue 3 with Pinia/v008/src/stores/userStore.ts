import User from "@/types/user"
import { defineStore } from "pinia"
import { computed, ref } from "vue"

export const useUserStore = defineStore('UserStore',()=>{
//state
const user = ref<User>({
    userName : 'John Doe',
    age : 35,
})
//getters
const IsSeniorCitizen = computed(()=> user.value.age >= 60);
//methods
const Reset = ()=> {
    user.value = {
        userName : 'John Doe',
        age : 35,
    };
}

return {
    user, IsSeniorCitizen, Reset
};
})
