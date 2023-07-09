import User from "@/types/user"
import { defineStore } from "pinia"

export const useUserStore = defineStore('UserStore',{
//state
state : () : User =>({
    userName : 'Jia And Naina',
    address : 'Sample'
})
//getters
//methods
})
