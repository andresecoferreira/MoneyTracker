// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/MNT/menu/MNT_11',
			name: 'menu-MNT_11',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_11/QMenuMnt11.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '11',
				baseArea: 'GROUP',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
	]
}
