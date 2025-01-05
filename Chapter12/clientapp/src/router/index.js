import { createRouter, createWebHistory } from 'vue-router';
import LogisticsList from '../components/LogisticsList.vue';
import LogisticsDetails from '../components/LogisticsDetails.vue';
import LogisticsForm from '../components/LogisticsForm.vue';

const routes = [
  {
    path: '/logistics',
    name: 'LogisticsList',
    component: LogisticsList,
  },
  {
    path: '/logistics/:id',
    name: 'LogisticsDetails',
    component: LogisticsDetails,
  },
  {
    path: '/logistics/add',
    name: 'AddLogisticsItem',
    component: LogisticsForm,
  },
  {
    path: '/logistics/edit/:id',
    name: 'EditLogisticsItem',
    component: LogisticsForm,
  },
  {
    path: '/',
    redirect: '/logistics',
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
