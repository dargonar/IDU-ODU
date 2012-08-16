<?php

require_once dirname(__FILE__).'/../lib/pcb_ensayos_realizadosGeneratorConfiguration.class.php';
require_once dirname(__FILE__).'/../lib/pcb_ensayos_realizadosGeneratorHelper.class.php';

/**
 * pcb_ensayos_realizados actions.
 *
 * @package    sf_sandbox
 * @subpackage pcb_ensayos_realizados
 * @author     Your name here
 * @version    SVN: $Id: actions.class.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class pcb_ensayos_realizadosActions extends autoPcb_ensayos_realizadosActions
{
  public function executeListPlaca(sfWebRequest $request){
    $resultadoensayo = $this->getRoute()->getObject();
    
    // $filters = $this->getUser()->getAttribute('ensayo.filters', $this->configuration->getFilterDefaults(), 'admin_module');
    // $filters['id'] = array('text'=>$placa->getEnsayoId());
    // $this->getUser()->setAttribute('ensayo.filters', $filters, 'admin_module');
    $this->redirect(array('sf_route' => 'placa_edit', 'sf_subject' => $resultadoensayo->getPlaca()));
    
  }
}
