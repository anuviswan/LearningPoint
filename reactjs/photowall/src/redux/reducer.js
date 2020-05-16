import initialPosts from '../data/posts'
import { combineReducers } from 'redux'

const rootReducer = combineReducers({ posts, comments });

function posts(state = initialPosts, action) {
    switch (action.type) {
        case 'REMOVE_POST':
            return [...state.slice(0, action.index), ...state.slice(action.index + 1)]
        case 'ADD_POST':
            return [...state, action.post]
        case 'LOAD_POSTS':
            return action.posts;
        default:
            return state;
    }
    return state;
}


function comments(state = {}, action) {
    switch (action.type) {
        case 'ADD_COMMENT':

            if (!state[action.postId]) {
                return { ...state, [action.postId]: [action.comment] }
            }
            else {
                return { ...state, [action.postId]: [...state[action.postId], action.comment] }
            }

        default:
            return state;
    }
    return state;
}

export default rootReducer;