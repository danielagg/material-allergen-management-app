<script lang="ts">
	export let unitOfMeasureId: string;
	export let initialStock: number;
</script>

<div class="w-full flex items-center justify-between gap-x-4">
	<div class="w-1/2">
		<label class="label">
			<span>Initial Stock</span>
			<input
				class={`input`}
				type="number"
				name="initialStock"
				bind:value={initialStock}
				placeholder="The initial stock of the material"
			/>
		</label>
	</div>
	<div class="w-1/2">
		<label class="label">
			<span>Unit of Measure</span>
			<select
				class="select"
				bind:value={unitOfMeasureId}
				on:change={(e) => (unitOfMeasureId = e.currentTarget.value)}
			>
				<option value="g">Gram</option>
				<option value="kg">Kilogram</option>
				<!-- <option value="Milliliter">Milliliter</option> -->
				<!-- <option value="Liter">Liter</option> -->
				<!-- <option value="Piece">Piece</option> -->
			</select>
		</label>
	</div>
</div>
