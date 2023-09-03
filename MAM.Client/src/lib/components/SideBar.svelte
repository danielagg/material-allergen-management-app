<script lang="ts">
	import Icon from '@iconify/svelte';
	import { AppRail, AppRailTile, AppRailAnchor } from '@skeletonlabs/skeleton';
	import { page } from '$app/stores';

	let currentRailCategory: '/' | '/inventory' | '/statistics' | '/settings' = '/';

	page.subscribe((page) => {
		// ex: /basePath/...
		let basePath: string = page.url.pathname.split('/')[1];
		if (!basePath) return;
		// Translate base path to link section
		if ('' == basePath) currentRailCategory = '/';
		if ('inventory' == basePath) currentRailCategory = '/inventory';
		if ('statistics' == basePath) currentRailCategory = '/statistics';
		if ('settings' == basePath) currentRailCategory = '/settings';
	});
</script>

<AppRail class="border-r border-surface-500">
	<AppRailTile bind:group={currentRailCategory} name="tile-2" value={'/'} title="tile-2">
		<svelte:fragment slot="lead">
			<a href="/" data-sveltekit-preload-data="hover">
				<div class="flex justify-center">
					<Icon icon="mdi:gluten" style="font-size: 28px" />
				</div>
			</a>
		</svelte:fragment>
		<span>Allergens</span>
	</AppRailTile>
	<AppRailTile bind:group={currentRailCategory} name="tile-2" value={'/inventory'} title="tile-2">
		<svelte:fragment slot="lead">
			<a href="/inventory" data-sveltekit-preload-data="hover">
				<div class="flex justify-center">
					<Icon icon="fa-solid:warehouse" style="font-size: 28px" />
				</div>
			</a>
		</svelte:fragment>
		<span>Inventory</span>
	</AppRailTile>
	<AppRailTile bind:group={currentRailCategory} name="tile-2" value={'/statistics'} title="tile-2">
		<svelte:fragment slot="lead">
			<a href="/statistics" data-sveltekit-preload-data="hover">
				<div class="flex justify-center">
					<Icon icon="mdi:graph-box" style="font-size: 28px" />
				</div>
			</a>
		</svelte:fragment>
		<span>Statistics</span>
	</AppRailTile>
	<AppRailTile bind:group={currentRailCategory} name="tile-3" value={'/settings'} title="tile-3">
		<svelte:fragment slot="lead">
			<a href="/settings" data-sveltekit-preload-data="hover">
				<div class="flex justify-center">
					<Icon icon="material-symbols:settings" style="font-size: 28px" />
				</div>
			</a>
		</svelte:fragment>
		<span>Settings</span>
	</AppRailTile>
	<svelte:fragment slot="trail">
		<AppRailAnchor
			href="https://github.com/danielagg/material-allergen-management-app"
			target="_blank"
			title="View Source on GitHub"
		>
			<svelte:fragment slot="lead">
				<Icon icon="mdi:github" style="font-size: 28px" />
			</svelte:fragment>
			<span>Source</span>
		</AppRailAnchor>
	</svelte:fragment>
</AppRail>
