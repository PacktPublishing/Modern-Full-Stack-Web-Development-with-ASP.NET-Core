<template>
    <div>
      <ul>
        <li v-for="shipment in shipmentState.shipments" :key="shipment.id">
          {{ shipment.id }} - {{ shipment.status }}
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  import { inject } from 'vue';
  
  export default {
    setup() {
      const shipmentState = inject('shipmentState');
  
      return { shipmentState };
    },
  };
  </script>
