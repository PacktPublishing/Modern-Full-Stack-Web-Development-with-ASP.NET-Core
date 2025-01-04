<template>
    <div class="my-component">
      <h2>{{ title }}</h2>
      <p>{{ description }}</p>
    </div>
  </template>
  
  <script>
  export default {
    name: 'MyComponent',
    data() {
      return {
        title: 'My first Vue component!',
        description: 'I am proud of my first component.'
      };
    }
  };
  </script>
  
  <style scoped>
  .my-component {
    border: 1px solid black;
    padding: 15px;
    border-radius: 4px;
    background-color: blanchedalmond;
  }
  .my-component h2 {
    color: black;
  }
  </style>
  