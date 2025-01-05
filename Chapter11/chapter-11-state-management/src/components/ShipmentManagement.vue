<template>
    <div>
      <h2>Shipment Management</h2>
      <button @click="fetchShipments">Fetch Shipments</button>
      <ul>
        <li v-for="shipment in filteredShipments('all')" :key="shipment.id">
          {{ shipment.id }} - {{ shipment.status }}
          <button @click="updateStatus(shipment.id, 'delivered')">Mark as Delivered</button>
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  import { useStore } from 'vuex';
  
  export default {
    setup() {
      const store = useStore();
  
      const fetchShipments = () => {
        store.dispatch('fetchShipments');
      };
  
      const updateStatus = (id, status) => {
        store.commit('updateShipmentStatus', { id, status });
      };
  
      const filteredShipments = (status) => store.getters.filteredShipments(status);
  
      return {
        fetchShipments,
        updateStatus,
        filteredShipments,
      };
    },
  };
  </script>
