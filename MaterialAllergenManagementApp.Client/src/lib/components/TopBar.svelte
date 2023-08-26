<script lang="ts">
	import { AppBar, type PopupSettings } from '@skeletonlabs/skeleton';
	import { LightSwitch } from '@skeletonlabs/skeleton';
	import { Avatar } from '@skeletonlabs/skeleton';
	import { popup } from '@skeletonlabs/skeleton';
	import Icon from '@iconify/svelte';

	const popupFeatured: PopupSettings = {
		event: 'click',
		target: 'popupFeatured',
		placement: 'bottom'
	};
</script>

<AppBar
	gridColumns="grid-cols-3"
	class="py-5"
	shadow="shadow-xl"
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
