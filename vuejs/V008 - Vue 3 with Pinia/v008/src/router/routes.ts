import routesNames  from "./routeNames";
import { RouteRecordRaw } from 'vue-router'
import HomePage from '@/pages/public/HomePage.vue';
import StoreViewer from '@/components/StoreViewer.vue'
import StoreEditor from '@/components/StoreEditor.vue'

const routes: Array<RouteRecordRaw> = [
    {
      path: routesNames.home.path,
      name: routesNames.home.name,
      component: StoreViewer
    },

    {
      path: routesNames.edit.path,
      name: routesNames.edit.name,
      component: StoreEditor
    },
  
  ]


export default routes;