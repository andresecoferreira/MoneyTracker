<template>
	<q-dashboard
		v-if="componentOnLoadProc.loaded"
		v-bind="controls.dashboard"
		v-on="controls.dashboard.handlers" />
</template>

<script>
	import { computed } from 'vue'

	import { loadResources } from '@/plugins/i18n.js'
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import GenericMenuHandlers from '@/mixins/genericMenuHandlers.js'
	import DashboardHandlers from '@/mixins/dashboardHandlers.js'
	import { DashboardControl } from '@/mixins/dashboardControl.js'

	const requiredTextResources = ['QMenuMNT_21', 'hardcoded', 'messages']

	export default {
		name: 'QMenuMnt21',

		mixins: [
			GenericMenuHandlers,
			DashboardHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the form is used as a homepage.
			 */
			isHomePage: {
				type: Boolean,
				default: false
			}
		},

		expose: [
			'navigationId',
			'updateMenuNavigation'
		],

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuMNT_21', false),

				interfaceMetadata: {
					id: 'QMenuMNT_21', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'MNT_21',
					name: 'Dashboard',
					route: 'menu-MNT_21',
					order: '21'
				},

				controls: {
					dashboard: new DashboardControl({
						action: 'MNT_Menu_21',
						title: computed(() => this.Resources.DASHBOARD51597),
						groups: [
							{
								id: '_ACTIONS',
								hideGroup: false,
								order: 1,
								title: computed(() => vm.Resources.QUICK_ACTIONS51411),
							},
							{
								id: '_GRAPH',
								hideGroup: false,
								order: 6,
								title: computed(() => vm.Resources.TOP_EXPENSES45935),
							},
						],
					}, this)
				}
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// called before the route that renders this component is confirmed.
			// does NOT have access to `this` component instance,
			// because it has not been created yet when this guard is called!

			next((vm) => vm.updateMenuNavigation(to))
		},

		created()
		{
			this.componentOnLoadProc.addImmediateBusy(loadResources(this, requiredTextResources))
			this.componentOnLoadProc.addImmediateBusy(this.fetchDashboardData(this.controls.dashboard))
			this.componentOnLoadProc.once(() => this.controls.dashboard.init(), this)
		}
	}
</script>
