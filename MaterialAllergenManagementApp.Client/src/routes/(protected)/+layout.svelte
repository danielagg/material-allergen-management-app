<script lang="ts">
	import '../../app.postcss';
	import { AppShell, Drawer, Modal, initializeStores } from '@skeletonlabs/skeleton';
	import TopBar from '$lib/components/TopBar.svelte';
	import SideBar from '$lib/components/SideBar.svelte';

	// Floating UI for Popups
	import { computePosition, autoUpdate, flip, shift, offset, arrow } from '@floating-ui/dom';
	import { storePopup } from '@skeletonlabs/skeleton';

	storePopup.set({ computePosition, autoUpdate, flip, shift, offset, arrow }); // popup
	initializeStores(); // drawers
</script>

<svelte:head><title>Material Manager</title></svelte:head>

<Drawer />

<Modal />

<AppShell class="min-h-screen">
	<svelte:fragment slot="header">
		<TopBar />
	</svelte:fragment>

	<svelte:fragment slot="sidebarLeft">
		<SideBar />
	</svelte:fragment>

	<Drawer />

	<slot />
</AppShell>
