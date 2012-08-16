<?php

require_once dirname(__FILE__).'/../lib/pcb_etiquetaGeneratorConfiguration.class.php';
require_once dirname(__FILE__).'/../lib/pcb_etiquetaGeneratorHelper.class.php';

/**
 * pcb_etiqueta actions.
 *
 * @package    sf_sandbox
 * @subpackage pcb_etiqueta
 * @author     Your name here
 * @version    SVN: $Id: actions.class.php 23810 2009-11-12 11:07:44Z Kris.Wallsmith $
 */
class pcb_etiquetaActions extends autoPcb_etiquetaActions
{
  public function executeListItems(sfWebRequest $request){
    $etiqueta = $this->getRoute()->getObject();
    
    $filters = $this->getUser()->getAttribute('pcb_etiqueta_item.filters', $this->configuration->getFilterDefaults(), 'admin_module');
    //$filters['ensayoid'] = array('text'=>$ensayo->getId());
    $filters['etiquetaid'] = $etiqueta->getId();
    $this->getUser()->setAttribute('pcb_etiqueta_item.filters', $filters, 'admin_module');
    //$this->redirect(array('sf_route' => 'ensayo_edit', 'sf_subject' => $placa->getEnsayo()));
    $this->redirect("itemetiqueta");
  }
}
