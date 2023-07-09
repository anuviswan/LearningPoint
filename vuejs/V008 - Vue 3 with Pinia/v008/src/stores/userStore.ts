import User from "@/types/user"
import { defineStore } from "pinia"
import { computed, ref } from "vue"

export const useUserStore = defineStore('UserStore',()=>{
//state
const user = ref<User>({
    userName : 'Jia And Naina',
    age : 1,
})
//getters
const IsSeniorCitizen = computed(()=> user.value.age >= 60);
//methods
function SetUser(newUser:User){
    user.value =  newUser;
}

return {
    user, IsSeniorCitizen, SetUser
};
})
