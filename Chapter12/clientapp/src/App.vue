<template>
  <div id="app">
    <b-navbar toggleable="lg" type="dark" variant="primary">
      <b-container>
        <b-navbar-brand href="#">Logistics Management System</b-navbar-brand>
        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
        <b-collapse id="nav-collapse" is-nav>
          <b-navbar-nav>
            <b-nav-item to="/logistics" class="nav-link">Logistics Items List</b-nav-item>
            <b-nav-item to="/logistics/add" class="nav-link">Add New Logistics Item</b-nav-item>
          </b-navbar-nav>
        </b-collapse>
      </b-container>
    </b-navbar>

    <b-container class="mt-4">
      <router-view />
    </b-container>
  </div>
</template>

<script>
export default {
  name: 'App',
};
</script>

<style>
.nav-link {
  cursor: pointer;
}
</style>
