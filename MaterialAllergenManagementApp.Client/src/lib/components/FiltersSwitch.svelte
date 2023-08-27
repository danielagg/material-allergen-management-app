
<script lang="ts">
	import { getDrawerStore } from '@skeletonlabs/skeleton';
	import FilterTypes from '$lib/filterTypes';

    const drawerStore = getDrawerStore();
    
    console.log($drawerStore.id)
</script>

<div class="z-50">
    {#if $drawerStore.id === FilterTypes.Allergen}
    <div class="text-5xl font-bold text-red-400">Allergen filters</div>
    {:else if $drawerStore.id === FilterTypes.Inventory}
    <div>Inventory filters</div>
{:else}
    <!-- (fallback contents) -->
{/if}
</div>