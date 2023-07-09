interface IRouteInfo{
    name : string,
    path : string
}
export interface IRouteNames{
    home : IRouteInfo,
    edit : IRouteInfo,
}

const routesNames: Readonly<IRouteNames> = {
    home: { 
        name: "home",
        path :'/'
    },
    edit: {
        name : 'edit',
        path : '/edit'
    },
}

export default routesNames;