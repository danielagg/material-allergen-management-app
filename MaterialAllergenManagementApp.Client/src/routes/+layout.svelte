<script lang="ts">
	import '@skeletonlabs/skeleton/themes/theme-modern.css';
	import '@skeletonlabs/skeleton/themes/theme-gold-nouveau.css';

	import '@skeletonlabs/skeleton/styles/skeleton.css';
	import '../app.postcss';
	import { AppShell, AppBar } from '@skeletonlabs/skeleton';
	import { LightSwitch } from '@skeletonlabs/skeleton';
	import { Avatar } from '@skeletonlabs/skeleton';
	import { popup } from '@skeletonlabs/skeleton';
	import type { PopupSettings } from '@skeletonlabs/skeleton';
	import Icon from '@iconify/svelte';
	import { AppRail, AppRailTile, AppRailAnchor } from '@skeletonlabs/skeleton';
	import { computePosition, autoUpdate, offset, shift, flip, arrow } from '@floating-ui/dom';
	import { storePopup } from '@skeletonlabs/skeleton';

	storePopup.set({ computePosition, autoUpdate, offset, shift, flip, arrow });

	let currentTile: number = 0;

	const popupFeatured: PopupSettings = {
		event: 'click',
		target: 'popupFeatured',
		placement: 'bottom'
	};
</script>

<AppShell>
	<svelte:fragment slot="header">
		<AppBar
			gridColumns="grid-cols-3"
			class="py-5 shadow-lg"
			slotDefault="place-self-center"
			slotTrail="place-content-end"
		>
			<svelte:fragment slot="lead">
				<section class="gap-x-2 flex items-center">
					<Icon icon="mdi:list-box-outline" style="font-size: 24px" />
					<strong class="text-xl uppercase">Material Allergen Manager</strong>
				</section>
			</svelte:fragment>
			<svelte:fragment slot="trail">
				<LightSwitch />
				<div use:popup={popupFeatured}>
					<Avatar
						border="border-4 border-surface-300-600-token hover:!border-primary-500"
						cursor="cursor-pointer"
						width="w-12"
						initials="AD"
					/>
				</div>

				<div class="card p-4 w-72 shadow-xl" data-popup="popupFeatured">
					<div><p>Demo Content</p></div>
					<div class="arrow bg-surface-100-800-token" />
				</div>
			</svelte:fragment>
		</AppBar>
	</svelte:fragment>

	<svelte:fragment slot="sidebarLeft">
		<AppRail class="border-r border-surface-500">
			<AppRailTile bind:group={currentTile} name="tile-1" value={0} title="tile-1">
				<svelte:fragment slot="lead">
					<div class="flex justify-center">
						<Icon icon="iconamoon:home" style="font-size: 28px" />
					</div>
				</svelte:fragment>
				<span>Home</span>
			</AppRailTile>
			<AppRailTile bind:group={currentTile} name="tile-2" value={1} title="tile-2">
				<svelte:fragment slot="lead">
					<div class="flex justify-center">
						<Icon icon="material-symbols:edit" style="font-size: 28px" />
					</div>
				</svelte:fragment>
				<span>Materials</span>
			</AppRailTile>
			<AppRailTile bind:group={currentTile} name="tile-3" value={2} title="tile-3">
				<svelte:fragment slot="lead">
					<div class="flex justify-center">
						<Icon icon="material-symbols:settings" style="font-size: 28px" />
					</div>
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
	</svelte:fragment>

	<slot />
</AppShell>
