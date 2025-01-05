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
import { ref, computed, watch, onMounted } from 'vue';

export default {
  setup() {
    const count = ref(0);

    const increment = () => {
      count.value++;
    };

    const doubleCount = computed(() => count.value * 2);

    watch(count, (newValue) => {
      console.log(`Count changed to ${newValue}`);
    });

    onMounted(() => {
      console.log('Component has been mounted.');
    });

    return {
      count,
      increment,
      doubleCount,
    };
  },
};


</script>
