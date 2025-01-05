<template>
    <div>
      <h1>Shipment Details</h1>
      <p>Shipment ID: {{ shipmentId }}</p>
    </div>
  </template>
  
  <script>
  import { useRoute } from 'vue-router';
  
  export default {
    setup() {
      const route = useRoute();
      const shipmentId = route.params.id; 
  
      return { shipmentId };
    },
  };
  </script>
