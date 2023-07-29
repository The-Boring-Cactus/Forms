import { createWebHistory, createRouter } from "vue-router";
import HelloWorld from '../components/HelloWorld.vue'
import EditorVue from  '../components/EditorVue.vue'
import FormVue from '../components/FormVue.vue'
import FlowChart from '../components/FlowChart.vue'
const routes = [
  {
    path: '/',
    name: 'home',
    component: HelloWorld
  },
  {
    path: '/editor',
    name: 'editor',
    component: EditorVue
  },
  {
    path: '/diagram',
    name: 'FlowChart',
    component: FlowChart
  },
  {
    path: '/form',
    name: 'Form',
    component: FormVue
  },
];
const router = createRouter({
    history: createWebHistory(),
    routes,
  });
  
  export default router;