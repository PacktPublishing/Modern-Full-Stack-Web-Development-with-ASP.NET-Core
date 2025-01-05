<template>
    <div>
      <h1>{{ title }}</h1>
      <button @click="toggleStatus">{{ isActive ? 'Deactivate' : 'Activate' }}</button>
    </div>
  </template>
  
  <script>
  import { ref } from 'vue';
  
  export default {
    setup() {
      const title = ref('Component State Management');
      const isActive = ref(false);
  
      const toggleStatus = () => {
        isActive.value = !isActive.value;
      };
  
      return { title, isActive, toggleStatus };
    },
  };
  </script>
