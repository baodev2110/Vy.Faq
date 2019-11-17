<template>
  <div class="menu_container">
    <div>
      <img class="logo" src="../assets/logo.png" width="110" />
    </div>
    <div>
      <nav>
        <a
          :class="{'is_active': selectedItem===index}"
          href="#"
          v-for="(item, index) in items"
          :key="index"
          @click="$emit('change', index)"
        >{{item}}</a>
      </nav>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    items: {
      type: Array,
      default: () => []
    },
    selectedItem: {
      type: Number,
      default: 0
    },
  }
};
</script>

<style>
a {
  text-decoration: none;
  color: black;
  padding: 20px;
}
a.is_active {
  border-bottom: 2px solid black;
}
.menu_container {
  display: flex;
  align-items: center;
}
nav {
  margin-left: 40px;
}
</style>