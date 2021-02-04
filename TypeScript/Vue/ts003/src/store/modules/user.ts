import {VuexModule,Module,Mutation,Action} from "vuex-module-decorators"

@Module({namespaced:true, name:'test'})

class User extends VuexModule{
    public name:string='';

    @Mutation
    public setName(newName:string):void{
        this.name = newName;
    }

    @Action
    public updateName(newName:string):void{
        this.context.commit('setName',newName);
    }
}