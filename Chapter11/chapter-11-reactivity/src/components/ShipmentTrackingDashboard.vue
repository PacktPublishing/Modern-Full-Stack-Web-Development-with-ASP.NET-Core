<template>
    <div class="shipment-tracker">
      <h1>Shipment Tracking Dashboard</h1>
  
      <div class="filters">
        <label>
          <input type="radio" value="all" v-model="filterStatus" /> All
        </label>
        <label>
          <input type="radio" value="in-transit" v-model="filterStatus" /> In Transit
        </label>
        <label>
          <input type="radio" value="delivered" v-model="filterStatus" /> Delivered
        </label>
        <label>
          <input type="radio" value="delayed" v-model="filterStatus" /> Delayed
        </label>
      </div>
  
      <ul>
        <li v-for="shipment in filteredShipments" :key="shipment.id">
          <strong>{{ shipment.id }}</strong>: {{ shipment.status }}
        </li>
      </ul>
  
      <p>Total Shipments: {{ shipments.length }}</p>
      <p>Displayed Shipments: {{ filteredShipments.length }}</p>
    </div>
  </template>
  
  <script>
  import { ref, reactive, computed } from 'vue';
  
  export default {
    setup() {
      const shipments = reactive([
        { id: 'SHP1001', status: 'in-transit' },
        { id: 'SHP1002', status: 'delivered' },
        { id: 'SHP1003', status: 'delayed' },
        { id: 'SHP1004', status: 'in-transit' },
        { id: 'SHP1005', status: 'delivered' },
      ]);
  
      const filterStatus = ref('all');
  
      const filteredShipments = computed(() => {
        if (filterStatus.value === 'all') {
          return shipments;
        }
        return shipments.filter(shipment => shipment.status === filterStatus.value);
      });
  
      return {
        shipments,
        filterStatus,
        filteredShipments,
      };
    }
  };
  </script>
  
  <style scoped>
  .shipment-tracker {
    font-family: Arial, sans-serif;
    max-width: 500px;
    margin: auto;
    text-align: left;
  }
  
  .filters {
    margin-bottom: 20px;
  }
  
  label {
    margin-right: 10px;
  }
  
  ul {
    list-style-type: none;
    padding: 0;
  }
  
  li {
    margin: 8px 0;
  }
  
  li strong {
    color: #2c3e50;
  }
  </style>
