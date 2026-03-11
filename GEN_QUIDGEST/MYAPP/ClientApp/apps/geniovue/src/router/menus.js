// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/MNT/menu/MNT_121',
			name: 'menu-MNT_121',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_121/QMenuMnt121.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '121',
				baseArea: 'CATEGORY_TYPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_111',
			name: 'menu-MNT_111',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_111/QMenuMnt111.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '111',
				baseArea: 'GROUP',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_11111',
			name: 'menu-MNT_11111',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_11111/QMenuMnt11111.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '11111',
				baseArea: 'SOURCE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
				limitations: ['group' /* DB */, 'member' /* DB */],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_1111',
			name: 'menu-MNT_1111',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_1111/QMenuMnt1111.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '1111',
				baseArea: 'MEMBER',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['group' /* DB */],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_1211',
			name: 'menu-MNT_1211',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_1211/QMenuMnt1211.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '1211',
				baseArea: 'CATEGORY',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['category_type' /* DB */],
				isPopup: false
			}
		},
	]
}
