<script lang="ts">
	import { getDrawerStore, getModalStore } from '@skeletonlabs/skeleton';
	import Icon from '@iconify/svelte';
	import { Table } from '@skeletonlabs/skeleton';
	import type {
		DrawerSettings,
		ModalComponent,
		ModalSettings,
		TableSource
	} from '@skeletonlabs/skeleton';
	import { tableMapperValues } from '@skeletonlabs/skeleton';
	import { Paginator } from '@skeletonlabs/skeleton';
	import FilterTypes from '$lib/filterTypes';
	import CreateMaterial from '$lib/components/CreateMaterial.svelte';

	export let data;

	const drawerStore = getDrawerStore();
	const modalStore = getModalStore();

	const drawerSettings: DrawerSettings = {
		id: FilterTypes.Allergen,
		bgBackdrop: 'bg-gradient-to-tr from-primary-500/50 via-tertiary-500/50 to-secondary-500/50',
		width: 'w-[600px]',
		padding: 'p-4',
		rounded: 'rounded-xl',
		position: 'right'
	};

	const modalComponent: ModalComponent = {
		ref: CreateMaterial,
		props: { background: 'bg-red-500', blur: '1000' },
		slot: '<p>Skeleton</p>'
	};

	const modal: ModalSettings = {
		type: 'component',
		component: modalComponent
	};

	const dateOptions: Intl.DateTimeFormatOptions = {
		year: 'numeric',
		month: 'long',
		day: 'numeric'
	};

	const tableSimple: TableSource = {
		head: ['ID', 'Name', 'Type', 'Allergen by Nature?', 'Allergen by Cross Cont.?', 'Created On'],
		body: tableMapperValues(
			data.data.map((s) => ({
				id: s.material.id,
				name: s.material.name,
				type: s.materialType,
				allergenByNature: s.hasAllergensByNature,
				allergenByCC: s.hasAllergensByCrossContamination,
				createdOn: new Date(s.createdOn).toLocaleDateString('en-US', dateOptions)
			})),
			['id', 'name', 'type', 'allergenByNature', 'allergenByCC', 'createdOn']
		)
	};
</script>

<div class="container h-full mx-auto flex">
	<div class="flex flex-col py-4 w-full">
		<h2 class="h2 mt-6 font-bold">Allergen Management</h2>
		<p class="mt-2 w-2/3 text-sm opacity-60">
			Use this page to manage the allergen classification of each material.
		</p>
		<div class="mt-6 flex justify-between items-center space-x-2">
			<input class="input" type="text" placeholder="Search for materials..." />
			<button type="button" class="btn variant-filled" on:click={() => modalStore.trigger(modal)}>
				<span>
					<Icon icon="material-symbols:add" style="font-size: 24px" />
				</span>
				<span>Create New Material</span>
			</button>
		</div>
		<Table
			source={tableSimple}
			interactive={true}
			class="mt-4 border border-surface-500 shadow-xl "
		/>
		<div class="mt-4">
			<Paginator
				showPreviousNextButtons
				showFirstLastButtons
				maxNumerals={1}
				settings={{ page: 0, limit: 10, size: 50, amounts: [5, 10, 20] }}
			/>
		</div>
	</div>
</div>
