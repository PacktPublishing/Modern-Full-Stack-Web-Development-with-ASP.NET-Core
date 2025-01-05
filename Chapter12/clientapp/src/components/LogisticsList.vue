<template>
    <b-container>
      <b-card>
        <h1 class="card-title">Logistics Items</h1>
        <b-button variant="primary" @click="fetchLogisticsItems" class="mb-3">Refresh</b-button>
        
        <b-table :items="logisticsItems" :fields="fields" hover bordered>
          <template #cell(actions)="data">
            <b-button size="sm" variant="info" @click="viewDetails(data.item.id)">View Details</b-button>
            <b-button size="sm" variant="danger" @click="deleteItem(data.item.id)">Delete</b-button>
          </template>
        </b-table>
        
        <router-link to="/logistics/add">
          <b-button variant="success" class="mt-3">Add New Item</b-button>
        </router-link>
      </b-card>
    </b-container>
  </template>
  
  <script>
  import logisticsService from '../services/logisticsService';
  
  export default {
    data() {
      return {
        logisticsItems: [],
        fields: [
          { key: 'id', label: 'ID' },
          { key: 'itemName', label: 'Item Name' },
          { key: 'quantity', label: 'Quantity' },
          { key: 'location', label: 'Location' },
          { key: 'actions', label: 'Actions', sortable: false },
        ],
      };
    },
    methods: {
      fetchLogisticsItems() {
        logisticsService.getLogisticsItems().then((response) => {
          this.logisticsItems = response.data;
        });
      },
      viewDetails(id) {
        this.$router.push(`/logistics/${id}`);
      },
      deleteItem(id) {
        logisticsService.deleteLogisticsItem(id).then(() => {
          this.fetchLogisticsItems();
        });
      },
    },
    created() {
      this.fetchLogisticsItems();
    },
  };
  </script>
  
  <style scoped>
  .card-title {
    margin-bottom: 20px;
  }
  </style>
