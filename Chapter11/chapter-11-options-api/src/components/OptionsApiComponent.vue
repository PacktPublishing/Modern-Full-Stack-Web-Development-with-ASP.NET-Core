<template>
    <div>
        <b>Count: </b> {{ count }}
        <br><br>
        <b>Double Count: </b> {{ doubleCount  }}
        <br><br>
        <button @click="increment()">Increment</button>
        <br>
    </div>
    </template>
    <script>
    export default {
      data() {
        return {
          count: 0,
        };
      },
      methods: {
        increment() {
          this.count++;
        },
      },
      computed: {
        doubleCount() {
          return this.count * 2;
        },
      },
      watch: {
        count(newValue) {
          console.log(`Count changed to ${newValue}`);
        },
      },
      mounted() {
        console.log('Component has been mounted.');
      },
    };
    
    </script>
    