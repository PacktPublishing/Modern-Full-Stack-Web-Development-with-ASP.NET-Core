<template>
    <b-container>
      <b-card>
        <h1 class="card-title">{{ isEditMode ? 'Edit' : 'Add' }} Logistics Item</h1>
        <b-form @submit.prevent="saveItem">
          <b-form-group label="Item Name:" label-for="itemName">
            <b-form-input id="itemName" v-model="logisticsItem.itemName" required></b-form-input>
          </b-form-group>
  
          <b-form-group label="Quantity:" label-for="quantity">
            <b-form-input id="quantity" type="number" v-model="logisticsItem.quantity" required></b-form-input>
          </b-form-group>
  
          <b-form-group label="Location:" label-for="location">
            <b-form-input id="location" v-model="logisticsItem.location" required></b-form-input>
          </b-form-group>
  
          <b-button type="submit" variant="success">{{ isEditMode ? 'Update' : 'Add' }}</b-button>
          <router-link to="/logistics">
            <b-button variant="danger" class="ml-2">Cancel</b-button>
          </router-link>
        </b-form>
      </b-card>
    </b-container>
  </template>
  
  <script>
  import logisticsService from '../services/logisticsService';
  
  export default {
    data() {
      return {
        logisticsItem: {
          itemName: '',
          quantity: 0,
          location: '',
        },
        isEditMode: false,
      };
    },
    methods: {
      saveItem() {
        if (this.isEditMode) {
          logisticsService.updateLogisticsItem(this.$route.params.id, this.logisticsItem).then(() => {
            this.$router.push('/logistics');
          });
        } else {
          logisticsService.addLogisticsItem(this.logisticsItem).then(() => {
            this.$router.push('/logistics');
          });
        }
      },
      fetchLogisticsItem() {
        if (this.isEditMode) {
          logisticsService.getLogisticsItem(this.$route.params.id).then((response) => {
            this.logisticsItem = response.data;
          });
        }
      },
    },
    created() {
      this.isEditMode = !!this.$route.params.id;
      this.fetchLogisticsItem();
    },
  };
  </script>
  
  <style scoped>
  .card-title {
    margin-bottom: 20px;
  }
  </style>
