<script lang="ts">
	import { Table } from '@skeletonlabs/skeleton';
	import type { TableSource } from '@skeletonlabs/skeleton';
	import { tableMapperValues } from '@skeletonlabs/skeleton';

	const sourceData = [
		{
			position: 1,
			id: 'R10000000562943',
			type: 'Food',
			name: 'Hydrogen',
			weight: 1.0079,
			symbol: 'H'
		},
		{
			position: 2,
			id: 'P10000001279912',
			type: 'Perishable',
			name: 'Helium',
			weight: 4.0026,
			symbol: 'He'
		},
		{
			position: 3,
			id: 'R10000000499901',
			type: 'Beverage',
			name: 'Lithium',
			weight: 6.941,
			symbol: 'Li'
		},
		{
			position: 4,
			id: 'R10000000499899',
			type: 'Finished Product',
			name: 'Beryllium',
			weight: 9.0122,
			symbol: 'Be'
		},
		{
			position: 5,
			id: 'P10000001198112',
			type: 'Simple Packaging Material',
			name: 'Boron',
			weight: 10.811,
			symbol: 'B'
		},
		{
			position: 6,
			id: 'P10000001135292',
			type: 'Simple Packaging Material',
			name: 'Boron',
			weight: 10.811,
			symbol: 'B'
		},
		{
			position: 7,
			id: 'P10000001098812',
			type: 'Manufacturer Part',
			name: 'Boron',
			weight: 10.811,
			symbol: 'B'
		},
		{
			position: 7,
			id: 'R10000000312899',
			type: 'Finished Product',
			name: 'Boron',
			weight: 10.811,
			symbol: 'B'
		}
	];

	const tableSimple: TableSource = {
		// A list of heading labels.
		head: ['ID', 'Name', 'Type', 'Symbol', 'Weight'],
		// The data visibly shown in your table body UI.
		body: tableMapperValues(sourceData, ['id', 'name', 'type', 'symbol', 'weight'])
		// // Optional: The data returned when interactive is enabled and a row is clicked.
		// meta: tableMapperValues(sourceData, ['position', 'id', 'name', 'symbol', 'weight']),
		// Optional: A list of footer labels.
		// foot: ['Total', '', '<code class="code">5</code>']
	};
</script>

<div class="container h-full mx-auto flex">
	<div class="flex flex-col py-4 w-full">
		<h2 class="h2 mt-6 font-bold">Allergen Management</h2>
		<p class="w-2/3 mt-2 text-sm opacity-60">
			Use this page to manage the allergen classification of each material.
		</p>
		<Table
			source={tableSimple}
			interactive={true}
			class="mt-6 border border-surface-500 shadow-xl "
		/>
	</div>
</div>
