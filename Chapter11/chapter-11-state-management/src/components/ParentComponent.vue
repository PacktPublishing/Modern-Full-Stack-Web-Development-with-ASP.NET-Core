<template>
    <div>
      <h1>Logistics Dashboard</h1>
      <ShipmentList />
    </div>
  </template>
  
  <script>
  import { reactive, provide } from 'vue';
  import ShipmentList from './ShipmentList.vue';
  
  export default {
    components: { ShipmentList },
    setup() {
      const shipmentState = reactive({
        shipments: [
          { id: 'SHP1001', status: 'in-transit' },
          { id: 'SHP1002', status: 'delivered' },
        ],
      });
  
      provide('shipmentState', shipmentState);
  
      return {};
    },
  };
  </script>
