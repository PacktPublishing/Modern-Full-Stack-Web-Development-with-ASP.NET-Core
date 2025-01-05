<template>
    <b-container>
      <b-card>
        <h1 class="card-title">Logistics Item Details</h1>
        <div v-if="logisticsItem">
          <p><strong>Name:</strong> {{ logisticsItem.itemName }}</p>
          <p><strong>Quantity:</strong> {{ logisticsItem.quantity }}</p>
          <p><strong>Location:</strong> {{ logisticsItem.location }}</p>
          <router-link to="/logistics">
            <b-button variant="primary" class="mt-3">Back to List</b-button>
          </router-link>
        </div>
      </b-card>
    </b-container>
  </template>
  
  <script>
  import logisticsService from '../services/logisticsService';
  
  export default {
    data() {
      return {
        logisticsItem: null,
      };
    },
    methods: {
      fetchLogisticsItem() {
        const id = this.$route.params.id;
        logisticsService.getLogisticsItem(id).then((response) => {
          this.logisticsItem = response.data;
        });
      },
    },
    created() {
      this.fetchLogisticsItem();
    },
  };
  </script>
  
  <style scoped>
  .card-title {
    margin-bottom: 20px;
  }
  </style>
