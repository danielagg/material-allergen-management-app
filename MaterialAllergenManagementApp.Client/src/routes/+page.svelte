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

	enum MaterialAvailability {
		Available,
		LimitedAvailability,
		BackOrder,
		Unavailable
	}

	const formatMaterialAvailability = (value: MaterialAvailability) => {
		switch (value) {
			case MaterialAvailability.Available:
				return 'Available';
			case MaterialAvailability.LimitedAvailability:
				return 'Limited Availability';
			case MaterialAvailability.BackOrder:
				return 'Back Order';
			case MaterialAvailability.Unavailable:
				return 'Unavailable';
			default:
				return 'N/A';
		}
	};

	const sourceData = [
		{
			position: 1,
			id: 'R10000000562943',
			type: 'Food',
			name: 'All-purpose flour',
			unitOfMeasure: 'Kilogram',
			currentStock: 1500,
			availability: MaterialAvailability.Available,
			createdOn: '2023-08-16T13:23:50.0649867'
		}
		// {
		// 	position: 2,
		// 	id: 'P10000001279912',
		// 	type: 'Perishable',
		// 	name: 'Helium',
		// 	createdOn: '2023-07-18T13:23:50.0649867'
		// },
		// {
		// 	position: 3,
		// 	id: 'R10000000499901',
		// 	type: 'Beverage',
		// 	name: 'Lithium'
		// },
		// {
		// 	position: 4,
		// 	id: 'R10000000499899',
		// 	type: 'Finished Product',
		// 	name: 'Beryllium'
		// },
		// {
		// 	position: 5,
		// 	id: 'P10000001198112',
		// 	type: 'Simple Packaging Material',
		// 	name: 'Boron'
		// },
		// {
		// 	position: 6,
		// 	id: 'P10000001135292',
		// 	type: 'Simple Packaging Material',
		// 	name: 'Boron'
		// },
		// {
		// 	position: 7,
		// 	id: 'P10000001098812',
		// 	type: 'Manufacturer Part',
		// 	name: 'Boron'
		// },
		// {
		// 	position: 7,
		// 	id: 'R10000000312899',
		// 	type: 'Finished Product',
		// 	name: 'Boron'
		// }
	];

	const tableSimple: TableSource = {
		// A list of heading labels.
		head: ['ID', 'Name', 'Type', 'Availability', 'Current Stock', 'Unit of Measure', 'Created On'],
		// The data visibly shown in your table body UI.
		body: tableMapperValues(
			sourceData.map((s) => ({
				...s,
				availability: formatMaterialAvailability(s.availability),
				createdOn: new Date(s.createdOn).toLocaleDateString('en-US', dateOptions)
			})),
			['id', 'name', 'type', 'availability', 'currentStock', 'unitOfMeasure', 'createdOn']
		)
		// // Optional: The data returned when interactive is enabled and a row is clicked.
		// meta: tableMapperValues(sourceData, ['position', 'id', 'name', 'symbol', 'weight']),
		// Optional: A list of footer labels.
		// foot: ['Total', '', '<code class="code">5</code>']
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
