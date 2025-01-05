import { createStore } from 'vuex';

export default createStore({
  state() {
    return {
      shipments: [
        { id: 'SHP1001', status: 'in-transit' },
        { id: 'SHP1002', status: 'delivered' },
        { id: 'SHP1003', status: 'delayed' },
      ],
    };
  },
  getters: {
    filteredShipments: (state) => (status) => {
      if (status === 'all') {
        return state.shipments;
      }
      return state.shipments.filter(shipment => shipment.status === status);
    },
  },
  mutations: {
    addShipment(state, payload) {
      state.shipments.push(payload);
    },
    updateShipmentStatus(state, { id, status }) {
      const shipment = state.shipments.find(shipment => shipment.id === id);
      if (shipment) {
        shipment.status = status;
      }
    },
  },
  actions: {
    async fetchShipments({ commit }) {
      const data = await new Promise((resolve) => {
        setTimeout(() => {
          resolve([
            { id: 'SHP1004', status: 'in-transit' },
            { id: 'SHP1005', status: 'delayed' },
          ]);
        }, 1000);
      });
      data.forEach(shipment => commit('addShipment', shipment));
    },
  },
});
