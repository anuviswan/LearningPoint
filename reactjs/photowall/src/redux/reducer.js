import initialPosts from '../data/posts'

const postReducer = function posts(state = initialPosts, action) {
    console.log(action.index);
    return state;
}

export default postReducer;