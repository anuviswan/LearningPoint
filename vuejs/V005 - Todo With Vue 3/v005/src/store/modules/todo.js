const state = {
    todos:['asas','sdsdsds']
}

const getters={
    AllDoto:(state)=> state.todos
}

const mutations={
    addTodo:(state,item) => [...state.todos, item]
}

const actions={
    addTodo({commit},todo){
        commit("addTodo",todo);
    }
}

export default{
    state,getters,mutations,actions
}