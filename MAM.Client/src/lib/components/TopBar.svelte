<script lang="ts">
	import { AppBar } from '@skeletonlabs/skeleton';
	import { LightSwitch } from '@skeletonlabs/skeleton';
	import Icon from '@iconify/svelte';
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
	</svelte:fragment>
</AppBar>
