<script lang="ts">
	import '@skeletonlabs/skeleton/themes/theme-modern.css';
	import '@skeletonlabs/skeleton/styles/skeleton.css';
	import '../app.postcss';
	import { AppShell } from '@skeletonlabs/skeleton';

	import { computePosition, autoUpdate, offset, shift, flip, arrow } from '@floating-ui/dom';
	import { storePopup } from '@skeletonlabs/skeleton';
	import TopBar from '../lib/components/TopBar.svelte';
	import SideBar from '../lib/components/SideBar.svelte';

	storePopup.set({ computePosition, autoUpdate, offset, shift, flip, arrow });
</script>

<AppShell>
	<svelte:fragment slot="header">
		<TopBar />
	</svelte:fragment>

	<svelte:fragment slot="sidebarLeft">
		<SideBar />
	</svelte:fragment>

	<slot />
</AppShell>
