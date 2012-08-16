<?php

require_once dirname(__FILE__).'/../lib/pcb_ensayosGeneratorConfiguration.class.php';
require_once dirname(__FILE__).'/../lib/pcb_ensayosGeneratorHelper.class.php';

/**
 * pcb_ensayos actions.
 *
 * @package    sf_sandbox
 * @subpackage pcb_ensayos
 * @author     Your name here
 * @version    SVN: $Id: actions.class.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class pcb_ensayosActions extends autoPcb_ensayosActions
{
  public function executeListPlacas(sfWebRequest $request){
    $ensayo = $this->getRoute()->getObject();
    
    $filters = $this->getUser()->getAttribute('pcb_placa.filters', $this->configuration->getFilterDefaults(), 'admin_module');
    //$filters['ensayoid'] = array('text'=>$ensayo->getId());
    $filters['ensayoid'] = $ensayo->getId();
    $this->getUser()->setAttribute('pcb_placa.filters', $filters, 'admin_module');
    //$this->redirect(array('sf_route' => 'ensayo_edit', 'sf_subject' => $placa->getEnsayo()));
    $this->redirect("placa");
  }
  
  public function executeListParametros(sfWebRequest $request){
    $ensayo = $this->getRoute()->getObject();
    $filters = $this->getUser()->getAttribute('pcb_params_ensayos.filters', $this->configuration->getFilterDefaults(), 'admin_module');
    $filters['ensayoid'] = (string)$ensayo->getId(); //array('text'=>(string)$ensayo->getId());
    //$filters['ensayoid'] = array('185');
    $this->getUser()->setAttribute('pcb_params_ensayos.filters', $filters, 'admin_module');
    $this->redirect("ensayoparametro");
    //$this->redirect(array('sf_route' => 'etiqueta_edit', 'sf_subject' => $placa->getEtiqueta()));
  }
}
